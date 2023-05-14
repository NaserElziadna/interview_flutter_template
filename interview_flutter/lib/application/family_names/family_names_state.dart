abstract class FNState{}

class DataFNState extends FNState {
  final List<String> data;

  DataFNState(this.data);
}

class InitialFNState extends FNState {}
class LoadingFNState extends FNState {}
class ErrorFNState extends FNState {
  final String error;

  ErrorFNState({this.error = "Error"});
}