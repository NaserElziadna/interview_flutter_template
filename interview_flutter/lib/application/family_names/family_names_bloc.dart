import 'package:flutter_bloc/flutter_bloc.dart';
import '../../infrastructer/repositories/firebase_repository.dart';
import 'family_names_event.dart';
import 'family_names_state.dart';

class FNBloc extends Bloc<FNEvent, FNState> {
  final FirebaseRepository _firebaseRepository;

  FNBloc({required FirebaseRepository firebaseRepository})
      : _firebaseRepository = firebaseRepository,
        super(InitialFNState()) {
    on<FNEvent>(mapEventToState);
  }

  @override
  void mapEventToState(FNEvent event, Emitter<FNState> emit) async {
    if (event is FetchDataEvent) {
      emit(LoadingFNState());
      try {
        final data = await _firebaseRepository.getSomeData().first;
        emit(DataFNState(data));
      } catch (e) {
        emit(ErrorFNState(error: e.toString()));
      }
    }
  }

  // @override
  // Stream<FNState> mapEventToState(FNEvent event) async* {
  //   if (event is FetchDataEvent) {
  //     yield LoadingFNState();
  //     try {
  //       final data = await _firebaseRepository.getSomeData().first;
  //       yield DataFNState(data);
  //     } catch (e) {
  //       yield ErrorFNState(error: e.toString());
  //     }
  //   }
  // }
}
