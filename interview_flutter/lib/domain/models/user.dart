import 'dart:convert';

import 'package:collection/collection.dart';

import 'order.dart';

class User {
  String token;
  int id;
  String email;
  String username;
  bool isBlocked;

  List<Order> orders;
  
  User({
    required this.token,
    required this.id,
    required this.email,
    required this.username,
    required this.isBlocked,
    required this.orders,
  });

  User copyWith({
    String? token,
    int? id,
    String? email,
    String? username,
    bool? isBlocked,
    List<Order>? orders,
  }) {
    return User(
      token: token ?? this.token,
      id: id ?? this.id,
      email: email ?? this.email,
      username: username ?? this.username,
      isBlocked: isBlocked ?? this.isBlocked,
      orders: orders ?? this.orders,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'token': token,
      'id': id,
      'email': email,
      'username': username,
      'isBlocked': isBlocked,
      'orders': orders.map((x) => x.toMap()).toList(),
    };
  }

  factory User.fromMap(Map<String, dynamic> map) {
    return User(
      token: map['token'] ?? '',
      id: map['id']?.toInt() ?? 0,
      email: map['email'] ?? '',
      username: map['username'] ?? '',
      isBlocked: map['isBlocked'] ?? false,
      orders: List<Order>.from(map['orders']?.map((x) => Order.fromMap(x))),
    );
  }

  String toJson() => json.encode(toMap());

  factory User.fromJson(String source) => User.fromMap(json.decode(source));

  @override
  String toString() {
    return 'User(token: $token, id: $id, email: $email, username: $username, isBlocked: $isBlocked, orders: $orders)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;
    final listEquals = const DeepCollectionEquality().equals;
  
    return other is User &&
      other.token == token &&
      other.id == id &&
      other.email == email &&
      other.username == username &&
      other.isBlocked == isBlocked &&
      listEquals(other.orders, orders);
  }

  @override
  int get hashCode {
    return token.hashCode ^
      id.hashCode ^
      email.hashCode ^
      username.hashCode ^
      isBlocked.hashCode ^
      orders.hashCode;
  }
}
