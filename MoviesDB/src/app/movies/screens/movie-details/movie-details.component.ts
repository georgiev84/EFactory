import { Component, OnInit } from '@angular/core';
import { IMovie } from 'src/app/interfaces/movie';
import { MOVIES } from 'src/data/movies';
import { ActivatedRoute } from '@angular/router';
import { TmdbService } from 'src/app/services/tmdb/tmdb.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.scss']
})
export class MovieDetailsComponent implements OnInit {

  movie: IMovie;
  routerParameterId: number;

  constructor(private activatedRoute: ActivatedRoute,
    private tmdbService: TmdbService) {

    this.routerParameterId = activatedRoute.snapshot.params.id;
    this.tmdbService.movies(this.routerParameterId).subscribe(response => {
      this.movie = response;
    });

    //this.movie = MOVIES.results.find(movie => movie.id === +this.routerParameterId);
  }

  ngOnInit(): void {
  }

}
