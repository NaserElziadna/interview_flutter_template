import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:interview_flutter/domain/models/order.dart';

import '../../domain/dto/create_product.dart';
import '../../domain/models/product.dart';
import '../utils/token_storage.dart';

class OrderRepository {
  static const apiUrl = 'https://localhost:44317/api';

  OrderRepository();

  Future<List<Order>> fetchPizzaOrdersForAdmin() async {
    final token = await TokenStorage.getToken();
    if (token != null) {
      final headers = {'Authorization': 'Bearer $token'};

      final response =
          await http.get(Uri.parse("$apiUrl/Order/all-admin"), headers: headers);

      if (response.statusCode == 200) {
        final dynamic jsonResponse = jsonDecode(response.body);
        if (jsonResponse['code'] == 200 &&
            jsonResponse.containsKey('payload')) {
          final List<dynamic> payload = jsonResponse['payload'];
          final orders = payload.map((data) => Order.fromMap(data)).toList();
          return orders;
        }
        return [];
      } else {
        throw Exception('Failed to fetch pizza orders');
      }
    } else {
      throw Exception('User is not auth');
    }
  }

  Future<List<Order>> fetchPizzaOrdersForUser() async {
    final token = await TokenStorage.getToken();
    if (token != null) {
      final headers = {'Authorization': 'Bearer $token'};

      final response =
          await http.get(Uri.parse("$apiUrl/Order/all"), headers: headers);

      if (response.statusCode == 200) {
        final dynamic jsonResponse = jsonDecode(response.body);
        if (jsonResponse['code'] == 200 &&
            jsonResponse.containsKey('payload')) {
          final List<dynamic> payload = jsonResponse['payload'];
          final orders = payload.map((data) => Order.fromMap(data)).toList();
          return orders;
        }
        return [];
      } else {
        throw Exception('Failed to fetch pizza orders');
      }
    } else {
      throw Exception('User is not auth');
    }
  }
}
