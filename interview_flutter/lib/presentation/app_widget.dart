import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:interview_flutter/application/auth/auth_bloc.dart';
import 'package:interview_flutter/infrastructer/repositories/firebase_repository.dart';
import 'package:interview_flutter/infrastructer/repositories/product_repository.dart';

import '../application/family_names/family_names_bloc.dart';
import '../application/order/order_bloc.dart';
import '../application/product/product_bloc.dart';
import '../infrastructer/repositories/auth_repository.dart';
import '../infrastructer/repositories/order_repository.dart';
import 'pages/home_page.dart';

class AppWidget extends StatelessWidget {
  // final _router = app_router.Router();

  AppWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider(create: (_) => AuthBloc(AuthRepository())),
        BlocProvider(
            create: (_) => FNBloc(firebaseRepository: FirebaseRepository())),
        BlocProvider(
            create: (_) => ProductBloc(productRepository: ProductRepository())),
        BlocProvider(
            create: (_) => OrderBloc(orderRepository: OrderRepository())),
      ],
      child: const MaterialApp(
        debugShowCheckedModeBanner: false,
        home: HomePage(),
      ),
    );
  }
}

// class HomePage extends StatefulWidget {
//   const HomePage({
//     Key? key,
//   }) : super(key: key);

//   @override
//   State<HomePage> createState() => _HomePageState();
// }

// class _HomePageState extends State<HomePage> {
//   AppCounterBloc? bloc;
//   FNBloc? firebase_bloc;

//   @override
//   void initState() {
//     bloc = BlocProvider.of<AppCounterBloc>(context);
//     firebase_bloc = BlocProvider.of<FNBloc>(context);
//     super.initState();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       appBar: AppBar(
//         backgroundColor: Colors.pinkAccent,
//         title: const Text("Flutter Bloc 8.0.1"),
//         centerTitle: true,
//         automaticallyImplyLeading: false,
//       ),
//       floatingActionButton: FloatingActionButton(
//         backgroundColor: Colors.pinkAccent,
//         onPressed: () {
//           bloc?.add(IncrementEvent());
//         },
//         tooltip: 'Increment',
//         child: const Icon(Icons.add),
//       ),
//       body: Column(
//         mainAxisAlignment: MainAxisAlignment.center,
//         crossAxisAlignment: CrossAxisAlignment.center,
//         children: [
//           // Image.asset(
//           //   'assets/logo.png',
//           //   height: 150,
//           //   errorBuilder: (_,__,___){
//           //     return Text("No image found");
//           //   },
//           // ),
//           IconButton(
//               onPressed: () {
//                 firebase_bloc!.add(FetchDataEvent());
//               },
//               icon: const Icon(Icons.refresh)),
//           const SizedBox(
//             height: 40,
//           ),
//           BlocBuilder<FNBloc, FNState>(
//             builder: (context, currentState) {
//               if (currentState is DataFNState) {
//                 return Center(
//                   child: Column(
//                     mainAxisAlignment: MainAxisAlignment.center,
//                     children: <Widget>[
//                       Text(
//                         currentState.data.join("|-|"),
//                         style: const TextStyle(
//                             color: Colors.blueGrey, fontSize: 30),
//                       ),
//                     ],
//                   ),
//                 );
//               } else if (currentState is LoadingFNState) {
//                 return const Center(child: CircularProgressIndicator());
//               }
//               return Text(
//                 'Press Load',
//               );
//             },
//           ),
//           IconButton(
//             onPressed: () => bloc?.add(InfintyIncrementEvent()),
//             icon: const Icon(Icons.loop),
//           ),
//           BlocBuilder<AppCounterBloc, AppCounterState>(
//             builder: (context, currentState) {
//               if (currentState is CounterValueState) {
//                 return Center(
//                   child: Column(
//                     mainAxisAlignment: MainAxisAlignment.center,
//                     children: <Widget>[
//                       const Text(
//                         'You have pushed the button this many times:',
//                         style: TextStyle(fontSize: 18),
//                       ),
//                       const SizedBox(
//                         height: 10,
//                       ),
//                       Text(
//                         currentState.counter.toString(),
//                         style: const TextStyle(
//                             color: Colors.blueGrey, fontSize: 30),
//                       ),
//                     ],
//                   ),
//                 );
//               }
//               return Center(
//                 child: Column(
//                   mainAxisAlignment: MainAxisAlignment.center,
//                   children: const <Widget>[
//                     Text(
//                       'You have pushed the button this many times:',
//                     ),
//                     SizedBox(
//                       height: 10,
//                     ),
//                     Text(
//                       "0",
//                       style: TextStyle(color: Colors.blueGrey, fontSize: 30),
//                     ),
//                   ],
//                 ),
//               );
//             },
//           ),
//         ],
//       ),
//     );
//   }
// }
