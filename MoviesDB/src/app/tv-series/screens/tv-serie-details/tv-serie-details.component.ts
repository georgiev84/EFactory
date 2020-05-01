import { Component, OnInit } from '@angular/core';
import { ITVShow } from 'src/app/interfaces/tv';
import { TV_SHOWS } from 'src/data/tvshows';
import { ActivatedRoute } from '@angular/router';
import { TmdbService } from 'src/app/services/tmdb/tmdb.service';

@Component({
  selector: 'app-tv-serie-details',
  templateUrl: './tv-serie-details.component.html',
  styleUrls: ['./tv-serie-details.component.scss']
})
export class TvSerieDetailsComponent implements OnInit {

  tvShow: ITVShow;
  routerParameterId: number;

  constructor(private activatedRoute: ActivatedRoute, private tmdbService: TmdbService) {
    this.routerParameterId = activatedRoute.snapshot.params.id;

    this.tmdbService.tVshowDetails(this.routerParameterId).subscribe(response => {
       this.tvShow = response;
    });
    // this.tvShow = TV_SHOWS.results.find(tvShow => tvShow.id === +this.routerParameterId);
  }

  ngOnInit(): void {
  }

}
