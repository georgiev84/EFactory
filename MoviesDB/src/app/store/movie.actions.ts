import {createAction, props} from "@ngrx/store";
import {IMovie} from "../interfaces/movie";

export const loadMovies = createAction(
  '[Movies List Component] Load Movies',
  props<{filters: any}>()
);

export const loadMoviesSuccess = createAction(
  '[Movies List Component] Load Movies Success',
  props<{movies: IMovie[]}>()
);

export const loadMoviesFailure = createAction(
  '[Movies List Component] Load Movies Success',
  props<{error: any}>()
);

