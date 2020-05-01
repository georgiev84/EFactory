import { Component, OnInit } from '@angular/core';
import { ITVShow } from 'src/app/interfaces/tv';
import { TV_SHOWS } from '../../../../data/tvshows';
import { TmdbService, TMDB_SORTING_OPTIONS, TMDB_YEARS_LIST, TMDB_GENRE_OPTIONS } from 'src/app/services/tmdb/tmdb.service';
import {IMovie} from "../../../interfaces/movie";
import {DataStorageService} from "../../../services/data-storage/data-storage.service";
import {AuthService} from "../../../services/auth/auth.service";

@Component({
  selector: 'app-tv-series-list',
  templateUrl: './tv-series-list.component.html',
  styleUrls: ['./tv-series-list.component.scss']
})
export class TvSeriesListComponent implements OnInit {

  tvShows: ITVShow[];
  currentUser: any;

  filterSettings = {
    sort_by: TMDB_SORTING_OPTIONS[0].value.toString(),
    //primary_release_year: TMDB_YEARS_LIST[0].value.toString(),
   with_genres: TMDB_GENRE_OPTIONS[0].value.toString()
  }

  constructor(
    private tmdbService: TmdbService,
    private dataStorageService: DataStorageService,
    private authService: AuthService
) {

  }

  ngOnInit(): void {
    this.tmdbService.tvSeries(this.filterSettings).subscribe(response => {
      this.tvShows = response.results;
    });

    this.authService.userState.subscribe(user => {
      this.currentUser = user;
    });
  }
  onGenreChanged(value: string){
    this.filterSettings.with_genres = value;
    this.tmdbService.tvSeries(this.filterSettings)
    .subscribe(response => {
    this.tvShows = response.results;
    });
  }

  onSortByChanged(value: string){
    this.filterSettings.sort_by = value;
    this.tmdbService.tvSeries(this.filterSettings)
    .subscribe(response => {
    this.tvShows = response.results;
    });
  }

  addToWatchlist(movie: ITVShow) {
    this.dataStorageService.addMediaWatchlist(movie, this.currentUser.uid, (error)=> {
      if(error){
        console.log('error');
      } else {
        //console.log('success');
      }
    })
  }

  addToFavourites(movie: ITVShow) {
    this.dataStorageService.addMediaFavouriteslist(movie, this.currentUser.uid, (error)=> {
      if(error){
        console.log('error');
      } else {
        console.log('success');
      }
    })
  }

}
