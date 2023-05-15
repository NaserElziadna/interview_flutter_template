import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../../application/auth/auth_bloc.dart';
import '../../application/auth/auth_event.dart';
import '../../application/auth/auth_state.dart';

class RegisterPage extends StatefulWidget {
  @override
  _RegisterPageState createState() => _RegisterPageState();
}

class _RegisterPageState extends State<RegisterPage> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _personalNameController = TextEditingController();
  final TextEditingController _familyNameController = TextEditingController();
  final TextEditingController _birthDateController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  String _selectedGender = '';

  final _genders = ['Male', 'Female', 'None'];

  @override
  Widget build(BuildContext context) {
    final AuthBloc authBloc = BlocProvider.of<AuthBloc>(context);
    return BlocListener<AuthBloc, AuthState>(
      listener: (context, state) {
        if (state is AuthGoLogIn) {
          // Show a success message or navigate to another page
          showDialog(
            context: context,
            builder: (context) => AlertDialog(
              title: Text('Registration Successful'),
              content: Text('You have successfully registered as a customer.'),
              actions: [
                ElevatedButton(
                  onPressed: () {
                    Navigator.pop(context); // Close the dialog
                  },
                  child: Text('OK'),
                ),
              ],
            ),
          );
        }
      },
      child: Scaffold(
        appBar: AppBar(
          title: Text('Register'),
        ),
        body: Padding(
          padding: EdgeInsets.all(16.0),
          child: Form(
            key: _formKey,
            child: ListView(
              children: [
                TextFormField(
                  controller: _emailController,
                  decoration: InputDecoration(labelText: 'Email'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your email';
                    }
                    // Add email validation logic if needed
                    return null;
                  },
                ),
                TextFormField(
                  controller: _personalNameController,
                  decoration: InputDecoration(labelText: 'Personal Name'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your personal name';
                    }
                    // Add validation logic if needed
                    return null;
                  },
                ),
                TextFormField(
                  controller: _familyNameController,
                  decoration: InputDecoration(labelText: 'Family Name'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your family name';
                    }
                    // Add validation logic if needed
                    return null;
                  },
                ),
                TextFormField(
                  controller: _birthDateController,
                  keyboardType: TextInputType.datetime,
                  decoration: InputDecoration(labelText: 'Birth Date'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your birth date';
                    }
                    // Add validation logic if needed
                    return null;
                  },
                ),
                // DropdownButtonFormField<String>(
                //   value: _selectedGender,
                //   decoration: InputDecoration(labelText: 'Gender'),
                //   items: _genders.map((String gender) {
                //     return DropdownMenuItem(
                //       value: gender,
                //       child: Text(gender),
                //     );
                //   }).toList(),
                //   onChanged: (String? value) {
                //     setState(() {
                //       _selectedGender = value!;
                //     });
                //   },
                //   validator: (value) {
                //     if (value == null || value.isEmpty) {
                //       return 'Please select your gender';
                //     }
                //     // Add validation logic if needed
                //     return null;
                //   },
                // ),
                TextFormField(
                  controller: _passwordController,
                  obscureText: true,
                  decoration: InputDecoration(labelText: 'Password'),
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Please enter your password';
                    }
                    // Add password validation logic if needed
                    return null;
                  },
                ),
                SizedBox(height: 16.0),
                ElevatedButton(
                  onPressed: () {
                    if (_formKey.currentState!.validate()) {
                      // Form fields are valid, perform registration logic here
                      // Register the customer using the provided information
                      final String email = _emailController.text;
                      final String personalName = _personalNameController.text;
                      final String familyName = _familyNameController.text;
                      final String birthDate = _birthDateController.text;
                      final String gender = _selectedGender;
                      final String password = _passwordController.text;

                      // Perform any necessary actions with the registration data
                      // For example, send the data to the server or perform local registration
                      authBloc.add(RegisterEvent(
                          email, password, personalName + " " + familyName));
                      // Clear the form fields after registration
                      // _emailController.clear();
                      // _personalNameController.clear();
                      // _familyNameController.clear();
                      // _birthDateController.clear();
                      // _selectedGender = "";
                      // _passwordController.clear();
                    }
                  },
                  child: Text('Register'),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
