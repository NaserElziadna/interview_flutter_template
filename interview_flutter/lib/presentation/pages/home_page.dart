import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../application/auth/auth_bloc.dart';
import '../../application/auth/auth_state.dart';
import 'dashboard_page.dart';
import 'login_page.dart';


class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final authBloc = BlocProvider.of<AuthBloc>(context);
    // Use the authBloc to handle authentication flow and UI changes
    // based on the authentication state (e.g., show login or dashboard)
    return BlocBuilder<AuthBloc, AuthState>(
      builder: (context, state) {
        if (state is AuthAuthenticated) {
          // User is authenticated, show the dashboard or authorized screen
          return DashboardPage();
        } else {
          // User is not authenticated, show the login page
          return LoginPage();
        }
      },
    );
  }
}
