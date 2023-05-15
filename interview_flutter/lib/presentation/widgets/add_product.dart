import 'package:flutter/material.dart';
import 'package:interview_flutter/domain/dto/create_product.dart';

import '../../application/product/product_bloc.dart';
import '../../application/product/product_event.dart';

class AddProductDialog extends StatefulWidget {
  final ProductBloc productBloc;

  AddProductDialog({required this.productBloc});

  @override
  _AddProductDialogState createState() => _AddProductDialogState();
}

class _AddProductDialogState extends State<AddProductDialog> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController _nameController = TextEditingController();
  final TextEditingController _priceController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Add Product'),
      content: Form(
        key: _formKey,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextFormField(
              controller: _nameController,
              decoration: InputDecoration(labelText: 'Name'),
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Please enter the product name';
                }
                return null;
              },
            ),
            TextFormField(
              controller: _priceController,
              decoration: InputDecoration(labelText: 'Price'),
              keyboardType: TextInputType.number,
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Please enter the product price';
                }
                try {
                  final double price = double.parse(value);
                  // Check if the parsed value is a number
                  if (price.isNaN) {
                    return 'Invalid price. Please enter a valid number';
                  }
                } catch (e) {
                  return 'Invalid price. Please enter a valid number';
                }
                return null;
              },
            ),
          ],
        ),
      ),
      actions: [
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: Text('Cancel'),
        ),
        ElevatedButton(
          onPressed: () {
            if (_formKey.currentState!.validate()) {
              final name = _nameController.text;
              final price = double.parse(_priceController.text);

              // Create the new product
              final newProduct = CreateProductDTO(
                name: name,
                price: price,
              );

              // Call the bloc method to add the product
              widget.productBloc.add(AddProductEvent(newProduct));

              Navigator.of(context).pop();
            }
          },
          child: Text('Add'),
        ),
      ],
    );
  }
}
