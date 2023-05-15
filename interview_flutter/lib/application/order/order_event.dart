// Events
import '../../domain/models/order.dart';

abstract class OrderEvent {}

class AddProductToOrder extends OrderEvent {
  final int orderId;

  AddProductToOrder(this.orderId);
}

class ClearOrder extends OrderEvent {}

class GetAllOrders extends OrderEvent {
  final List<Order> orders;

  GetAllOrders(this.orders); 
}