import {IMovie} from "../interfaces/movie";
import {createReducer, on} from "@ngrx/store";
import * as movieActions from './movie.actions'

export const movieStateFeatureKey='moviesState';

export interface IMoviesState {
  movies: IMovie[];
  error: any;
  isLoading: boolean;
}

export const initialState: IMoviesState = {
  movies: null,
  error: null,
  isLoading: false
}

export const reducers = createReducer(
  initialState,
  on(movieActions.loadMovies,(state, action)=>{
    return {
      ...state,
      isLoading: true,
    };
  }),
  on(movieActions.loadMoviesSuccess, (state, action)=>{
    return{
      ...state,
      isLoading: false,
      movies: action.movies
    };
  }),
  on(movieActions.loadMoviesFailure, (state, action)=>{
    return{
      ...state,
      isLoading: false,
      error: action.error
    };
  })
)
