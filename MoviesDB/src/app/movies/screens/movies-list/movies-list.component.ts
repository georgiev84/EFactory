import { Component, OnInit } from '@angular/core';
import { IMovie } from 'src/app/interfaces/movie';
import { TmdbService, TMDB_SORTING_OPTIONS, TMDB_YEARS_LIST, TMDB_GENRE_OPTIONS } from 'src/app/services/tmdb/tmdb.service';
import {DataStorageService} from "../../../services/data-storage/data-storage.service";
import {AuthService} from "../../../services/auth/auth.service";
import {IMoviesState} from "../../../store";
import {Store} from "@ngrx/store";
import * as fromMovieActions from '../../../store/movie.actions'


@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.scss']
})
export class MoviesListComponent implements OnInit {

  movies: IMovie[];
  currentUser: any;

  //default filtration options
  filterSettings = {
    sort_by: TMDB_SORTING_OPTIONS[0].value.toString(),
    primary_release_year: TMDB_YEARS_LIST[0].value.toString(),
    with_genres: TMDB_GENRE_OPTIONS[0].value.toString()
  }

  constructor(
    private tmdbService: TmdbService,
    private dataStorageService: DataStorageService,
    private authService: AuthService,
    private store: Store<IMoviesState>
  ) {


  }

  ngOnInit(): void {
    this.store.dispatch(fromMovieActions.loadMovies({filters: this.filterSettings}));

    this.tmdbService.discover(this.filterSettings)
      .subscribe(response => {
        this.movies = response.results;
      });

    this.authService.userState.subscribe(user => {
      this.currentUser = user;
    });


  }

  onGenreChanged(value: string){
    this.filterSettings.with_genres = value;
    this.tmdbService.discover(this.filterSettings)
    .subscribe(response => {
    this.movies = response.results;
    });
  }

  onYearsChanged(value: string){
    this.filterSettings.primary_release_year = value;
    this.tmdbService.discover(this.filterSettings)
    .subscribe(response => {
    this.movies = response.results;
    });

  }

  onSortByChanged(value: string){
    this.filterSettings.sort_by = value;
    this.tmdbService.discover(this.filterSettings)
    .subscribe(response => {
    this.movies = response.results;
    });
  }

  addToWatchlist(movie: IMovie) {
    this.dataStorageService.addMediaWatchlist(movie, this.currentUser.uid, (error)=> {
      if(error){
        console.log('error');
      } else {
        //console.log('success');
      }
    })
  }

  addToFavourites(movie: IMovie) {
    this.dataStorageService.addMediaFavouriteslist(movie, this.currentUser.uid, (error)=> {
      if(error){
        console.log('error');
      } else {
        console.log('success');
      }
    })
  }
}
