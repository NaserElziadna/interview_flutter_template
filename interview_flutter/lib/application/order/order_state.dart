// States
import '../../domain/models/order.dart';

abstract class OrderState {}

class OrderEmpty extends OrderState {}

class OrderInProgress extends OrderState {
  final Order order;

  OrderInProgress(this.order);
}

class AllOrder extends OrderState {
  final List<Order> orders;

  AllOrder(this.orders);
}
