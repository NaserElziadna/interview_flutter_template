import 'package:flutter_bloc/flutter_bloc.dart';

import 'app_event.dart';
import 'app_state.dart';

class AppCounterBloc extends Bloc<AppCounterEvent, AppCounterState> {
  AppCounterBloc() : super(CounterValueState(0)) {
    on<AppCounterEvent>(mapEventToState);
  }
  @override
  void mapEventToState(
      AppCounterEvent event, Emitter<AppCounterState> emit) async {
    if (event is IncrementEvent) {
      emit(CounterValueState(state.counter! + 1));
    } else if (event is InfintyIncrementEvent) {
      for (; ;) {
        
      }
    }
  }
}
