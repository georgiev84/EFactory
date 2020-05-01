import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPerson } from 'src/app/interfaces/peoples';
import { PEOPLE } from 'src/data/people';
import { TmdbService } from 'src/app/services/tmdb/tmdb.service';
import { IPeopleDetail } from 'src/app/interfaces/peoples';
import { IPeopleCredit } from 'src/app/interfaces/responses';

@Component({
  selector: 'app-people-detail',
  templateUrl: './people-detail.component.html',
  styleUrls: ['./people-detail.component.scss']
})
export class PeopleDetailComponent implements OnInit {

  person: IPeopleDetail;
  routerParameterId: number;

  credits: {
    cast: IPeopleCredit[],
    crew: IPeopleCredit[]
  } = { cast: [], crew: []}

  constructor(
    private activatedRoute: ActivatedRoute,
    private tmdbService: TmdbService,
    private router: Router
    ) {
    this.routerParameterId = activatedRoute.snapshot.params.id;

    this.tmdbService.peopleDetails(this.routerParameterId).subscribe(response => {
      this.person = response;


    this.tmdbService.peopleCombinedCredits(this.routerParameterId).subscribe(response => {
      this.credits = {
        cast: response.cast,
        crew: response.crew
      }
    });

   });

  }

  ngOnInit(): void {
  }

  redirectToMedia(mediaType: string, castId){
    const route = mediaType === 'movie'? '/movies' : '/tv-shows';
    this.router.navigate([route, castId]);
  }

}
