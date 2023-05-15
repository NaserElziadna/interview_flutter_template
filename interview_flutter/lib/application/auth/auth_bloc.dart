import 'package:bloc/bloc.dart';

import '../../infrastructer/repositories/auth_repository.dart';
import '../../infrastructer/utils/token_storage.dart';
import 'auth_event.dart';
import 'auth_state.dart';

class AuthBloc extends Bloc<AuthEvent, AuthState> {
  final AuthRepository authRepository;

  AuthBloc(this.authRepository) : super(AuthInitial()) {
    on<AuthEvent>(mapEventToState);
  }
  @override
  void mapEventToState(AuthEvent event, Emitter<AuthState> emit) async {
    if (event is LoginEvent) {
      // Perform login request to your API
      try {
        var t = await TokenStorage.getToken();
        if (t == null) {
          final token = await authRepository.login(event.email, event.password);
          // Save the token for future API requests
          // (You can use any storage solution here like shared preferences or secure storage)
          await saveTokenToStorage(token);
          t = token;
        }
        // Set the authentication state to authenticated
        emit(AuthAuthenticated(t));
      } catch (e) {
        emit(AuthUnauthenticated());
      }
    } else if (event is RegisterEvent) {
      // Perform login request to your API
      try {
        final token = await authRepository.register(
            event.email, event.password, event.name);
        // Set the authentication state to authenticated
        emit(AuthGoLogIn());
      } catch (e) {
        emit(AuthUnauthenticated());
      }
    } else if (event is LogoutEvent) {
      await TokenStorage.deleteToken();
      emit(AuthUnauthenticated());
    }
  }

  Future<void> saveTokenToStorage(String token) async {
    // Code to save the token to storage (e.g., shared preferences or secure storage)
    await TokenStorage.saveToken(token);
  }
  // @override
  // Stream<AuthState> mapEventToState(AuthEvent event) async* {
  //   if (event is LoginEvent) {
  //     yield* _mapLoginEventToState(event);
  //   } else if (event is LogoutEvent) {
  //     yield* _mapLogoutEventToState(event);
  //   }
  // }

  // // Stream<AuthState> _mapLoginEventToState(LoginEvent event) async* {
  // //   // Perform login request to your API
  // //   try {
  // //     final token = await authRepository.login(event.email, event.password);
  // //     // Save the token for future API requests
  // //     // (You can use any storage solution here like shared preferences or secure storage)
  // //     await saveTokenToStorage(token);

  // //     // Set the authentication state to authenticated
  // //     yield AuthAuthenticated(token);
  // //   } catch (e) {
  // //     yield AuthUnauthenticated();
  // //   }
  // // }

  // // Stream<AuthState> _mapLogoutEventToState(LogoutEvent event) async* {
  // //   // Perform logout logic, e.g., clear token, reset session, etc.
  // //   yield AuthUnauthenticated();
  // // }

}

// class AuthBloc extends Bloc<AuthEvent, AuthState> {
//   final AuthRepository authRepository;

//   AuthBloc(this.authRepository) : super(AuthInitial());

//   @override
//   Stream<AuthState> mapEventToState(AuthEvent event) async* {
//     if (event is LoginEvent) {
//       try {
//         // Perform the login API request using the provided credentials
//         final token = await authRepository.login(event.username, event.password);
//         // Save the token for future API requests
//         // (You can use any storage solution here like shared preferences or secure storage)
//         await saveTokenToStorage(token);

//         // Set the authentication state to authenticated
//         yield AuthAuthenticated();
//       } catch (e) {
//         // Handle the login error
//         yield AuthError('Login failed');
//       }
//     }
//     // Handle other events if needed
//   }

//   Future<void> saveTokenToStorage(String token) async {
//     // Code to save the token to storage (e.g., shared preferences or secure storage)
//   }
// }