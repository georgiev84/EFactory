import { Component, OnInit, Input } from '@angular/core';
import { IPerson, isMovie } from 'src/app/interfaces/peoples';
import { Router } from '@angular/router';

@Component({
  selector: 'app-people-list-item',
  templateUrl: './people-list-item.component.html',
  styleUrls: ['./people-list-item.component.scss']
})
export class PeopleListItemComponent implements OnInit {

  @Input() person: IPerson;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.formattedKnownFor();
  }

  formattedKnownFor(){
    return this.person.known_for.map(item => {
      return isMovie(item)? item.title : item.name;
    }).join(', ')
  }

  redirect(){
    this.router.navigate(['/people', this.person.id]);
  }
}
