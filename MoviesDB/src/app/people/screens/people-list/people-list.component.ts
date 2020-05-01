import { Component, OnInit, Input } from '@angular/core';
import { IPerson } from 'src/app/interfaces/peoples';
import { PEOPLE } from '../../../../data/people';
import { TmdbService } from 'src/app/services/tmdb/tmdb.service';
import { IKnownFor } from 'src/app/interfaces/peoples';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-people-list',
  templateUrl: './people-list.component.html',
  styleUrls: ['./people-list.component.scss']
})
export class PeopleListComponent implements OnInit {

  people: IPerson[];
  searchText = '';

  @Input() person: IPerson;


  test: IKnownFor[];
  constructor(private tmdbService: TmdbService) {

    this.tmdbService.people().subscribe(response => {
      this.people = response.results;
    });

    //this.people = PEOPLE.results;
  }

  ngOnInit(): void {
  }

}
