import 'package:flutter/material.dart';
import 'package:interview_flutter/domain/models/product.dart';

import '../../application/order/order_bloc.dart';
import '../../application/order/order_event.dart';

class ProductCard extends StatelessWidget {
  final Product product;
  final OrderBloc orderBloc;

  const ProductCard({Key? key, required this.product, required this.orderBloc})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      child: ListTile(
        title: Text(product.name),
        subtitle: Text('\$${product.price.toStringAsFixed(2)}'),
        trailing: ElevatedButton(
          onPressed: () {
            orderBloc.add(AddProductToOrder(product.id));
          },
          child: Text('Add to Order'),
        ),
      ),
    );
  }
}