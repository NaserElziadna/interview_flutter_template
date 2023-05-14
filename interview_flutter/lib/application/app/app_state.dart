abstract class AppCounterState {
  int? counter;
}
class CounterValueState extends AppCounterState {
  final int counter;

  CounterValueState(this.counter);

}