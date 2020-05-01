import {Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { IMovie } from 'src/app/interfaces/movie';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movies-list-item',
  templateUrl: './movies-list-item.component.html',
  styleUrls: ['./movies-list-item.component.scss']
})
export class MoviesListItemComponent implements OnInit {

  @Input() movie: IMovie;
  @Output() addedToWatchlist = new EventEmitter<IMovie>();
  @Output() addedToFavourites = new EventEmitter<IMovie>();

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  redirect(){
    this.router.navigate(['/movies', this.movie.id]);
  }

  addToWatchlist(){
    this.addedToWatchlist.emit(this.movie);
  }

  addToFavourites(){
    this.addedToFavourites.emit(this.movie);
  }

}
