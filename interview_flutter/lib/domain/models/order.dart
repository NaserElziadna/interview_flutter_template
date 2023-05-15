import 'dart:convert';

import 'product.dart';

class Order {
  Product product;
  OrderStatus state;

  Order({
    required this.product,
    required this.state
  });

  Order copyWith({
    Product? product,
    OrderStatus? state
  }) {
    return Order(
      product: product ?? this.product, state: state ?? this.state,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'product': product.toMap(),
      'state': state.index,
    };
  }

  factory Order.fromMap(Map<String, dynamic> map) {
    return Order(
      product: Product.fromMap(map['product']),
       state: map['state']?.toInt() ?? 0,
    );
  }

  String toJson() => json.encode(toMap());

  factory Order.fromJson(String source) => Order.fromMap(json.decode(source));

  @override
  String toString() => 'Order(product: $product)';

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;
  
    return other is Order &&
      other.product == product;
  }

  @override
  int get hashCode => product.hashCode;
}

enum OrderStatus {
  Created,
  Accepted,
  InProgress,
  Cancelled,
  Delivered,
  Done,
}