import 'dart:convert';

import 'package:http/http.dart' as http;

import '../../domain/dto/create_product.dart';
import '../../domain/models/product.dart';
import '../utils/token_storage.dart';

class ProductRepository {
  static const apiUrl = 'https://localhost:44317/api';

  ProductRepository();

  Future<List<Product>> fetchPizzaProducts() async {
  final token = await TokenStorage.getToken();
  if (token != null) {
    final headers = {'Authorization': 'Bearer $token'};

    final response =
        await http.get(Uri.parse("$apiUrl/Product/all"), headers: headers);

    if (response.statusCode == 200) {
      final dynamic jsonResponse = jsonDecode(response.body);
      if (jsonResponse['code'] == 200 && jsonResponse.containsKey('payload')) {
        final List<dynamic> payload = jsonResponse['payload'];
        final products = payload.map((data) => Product.fromMap(data)).toList();
        return products;
      }
      return [];
    } else {
      throw Exception('Failed to fetch pizza products');
    }
  } else {
    throw Exception('User is not auth');
  }

}

Future<void> addProduct(CreateProductDTO product) async {
    final token = await TokenStorage.getToken();
    if (token != null) {
      final headers = {
        'Authorization': 'Bearer $token',
        'Content-Type': 'application/json',
      };

      final body = jsonEncode(product.toMap());

      final response = await http.post(
        Uri.parse('$apiUrl/Product/add'),
        headers: headers,
        body: body,
      );

      if (response.statusCode == 200) {
        // Product added successfully
        // Handle any further operations or notifications here
      } else {
        throw Exception('Failed to add product');
      }
    } else {
      throw Exception('User is not auth');
    }
  }

}
