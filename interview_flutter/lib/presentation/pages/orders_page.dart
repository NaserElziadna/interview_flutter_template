import 'package:flutter/material.dart';
import 'package:interview_flutter/application/order/order_state.dart';
import 'package:interview_flutter/domain/models/product.dart';
import 'package:interview_flutter/domain/models/user.dart';
import 'package:interview_flutter/domain/models/order.dart';

class OrdersPage extends StatelessWidget {
  final prod = Product(id: 1, name: "pizaa", price: 12);
  late List<User> users = [];

  OrdersPage() {
     users = [
      User(
        email: 'elziadna10@gmail.com',
        id: 1,
        token: "sa",
        isBlocked: true,
        username: "dasd",
        orders: [Order(product: prod, state: OrderStatus.Accepted)],
      ), User(
        email: 'elziadna10@gmail.com',
        id: 1,
        token: "sa",
        isBlocked: true,
        username: "dasd",
        orders: [Order(product: prod, state: OrderStatus.Accepted)],
      ), User(
        email: 'elziadna10@gmail.com',
        id: 1,
        token: "sa",
        isBlocked: true,
        username: "dasd",
        orders: [Order(product: prod, state: OrderStatus.Accepted)],
      ), User(
        email: 'elziadna10@gmail.com',
        id: 1,
        token: "sa",
        isBlocked: true,
        username: "dasd",
        orders: [Order(product: prod, state: OrderStatus.Accepted)],
      ), User(
        email: 'elziadna10@gmail.com',
        id: 1,
        token: "sa",
        isBlocked: true,
        username: "dasd",
        orders: [Order(product: prod, state: OrderStatus.Accepted)],
      )
    ];
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Users and Orders'),
      ),
      body: ListView.builder(
        itemCount: users.length,
        itemBuilder: (context, userIndex) {
          final user = users[userIndex];
          return Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Padding(
                padding: const EdgeInsets.all(16.0),
                child: Text(
                  'User Information:',
                  style: TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              ListTile(
                title: Text('Name: ${user.username}'),
                subtitle: Text('Email: ${user.email}'),
              ),
              Divider(),
              Padding(
                padding: const EdgeInsets.all(16.0),
                child: Text(
                  'Orders:',
                  style: TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              ListView.builder(
                shrinkWrap: true,
                physics: ClampingScrollPhysics(),
                itemCount: user.orders.length,
                itemBuilder: (context, orderIndex) {
                  final order = user.orders[orderIndex];
                  return ListTile(
                    title: Text('Order ID: ${order.product.name}'),
                    subtitle: Text('Order Status: ${order.state}'),
                    // Add more information about the order as needed
                  );
                },
              ),
              Divider(),
            ],
          );
        },
      ),
    );
  }
}
