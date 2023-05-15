import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:interview_flutter/presentation/pages/orders_page.dart';
import 'package:interview_flutter/presentation/widgets/product_card.dart';

import '../../application/order/order_bloc.dart';
import '../../application/product/product_bloc.dart';
import '../../application/product/product_event.dart';
import '../../application/product/product_state.dart';
import '../widgets/add_product.dart';

class DashboardPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final productBloc = BlocProvider.of<ProductBloc>(context);
    productBloc.add(FetchProductsEvent());

    return Scaffold(
      appBar: AppBar(
        title: Text('Pizza Store'),
        actions: [
          IconButton(
              onPressed: () {
               Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => OrdersPage()),
                );
              },
              icon: const Icon(Icons.list)),
          IconButton(
              onPressed: () {
                productBloc.add(FetchProductsEvent());
              },
              icon: const Icon(Icons.refresh)),
          IconButton(
              onPressed: () {
                showDialog(
                  context: context,
                  builder: (BuildContext context) {
                    return AddProductDialog(
                      productBloc: BlocProvider.of<ProductBloc>(context),
                    );
                  },
                );
              },
              icon: const Icon(Icons.add))
        ],
      ),
      body: BlocBuilder<ProductBloc, ProductState>(
        builder: (context, state) {
          if (state is ProductLoading) {
            return Center(
              child: CircularProgressIndicator(),
            );
          } else if (state is ProductLoaded) {
            return ListView.builder(
              itemCount: state.products.length,
              itemBuilder: (context, index) {
                final product = state.products[index];
                return ProductCard(
                  product: product,
                  orderBloc: BlocProvider.of<OrderBloc>(context),
                );
              },
            );
          } else if (state is ProductError) {
            return Center(
              child: Text(state.errorMessage),
            );
          }

          return Container(); // Default empty state
        },
      ),
    );
  }
}
