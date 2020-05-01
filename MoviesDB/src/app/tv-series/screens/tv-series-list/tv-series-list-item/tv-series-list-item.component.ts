import {Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { ITVShow } from 'src/app/interfaces/tv';
import { Router } from '@angular/router';
import {IMovie} from "../../../../interfaces/movie";

@Component({
  selector: 'app-tv-series-list-item',
  templateUrl: './tv-series-list-item.component.html',
  styleUrls: ['./tv-series-list-item.component.scss']
})
export class TvSeriesListItemComponent implements OnInit {

  @Input() tvShow: ITVShow;
  @Output() addedToWatchlist = new EventEmitter<ITVShow>();
  @Output() addedToFavourites = new EventEmitter<ITVShow>();

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  redirect(){
    this.router.navigate(['/tv-shows', this.tvShow.id]);
  }

  addToWatchlist(){
    this.addedToWatchlist.emit(this.tvShow);
  }

  addToFavourites(){
    this.addedToFavourites.emit(this.tvShow);
  }
}
