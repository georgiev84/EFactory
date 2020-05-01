import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms';
import { ISelectOption } from 'src/app/interfaces/select-option';
import { TMDB_GENRE_OPTIONS, TMDB_YEARS_LIST, TMDB_SORTING_OPTIONS, TMDB_MULTI_GENRE_OPTIONS } from 'src/app/services/tmdb/tmdb.service';
import { IMultiSelect } from 'src/app/interfaces/multi-select';

@Component({
  selector: 'app-tv-series-filters',
  templateUrl: './tv-series-filters.component.html',
  styleUrls: ['./tv-series-filters.component.scss']
})
export class TvSeriesFiltersComponent implements OnInit {

  @Output() sortByChanged: EventEmitter<string> = new EventEmitter<string>();
  @Output() yearsChanged: EventEmitter<string> = new EventEmitter<string>();
  @Output() genreChanged: EventEmitter<string> = new EventEmitter<string>();
  @Output() multiGenreChanged: EventEmitter<string> = new EventEmitter<string>();

  filterFormGroup: FormGroup;
  filterSortByOptions: ISelectOption[] = TMDB_SORTING_OPTIONS;
  filterGenreOptions: ISelectOption[] = TMDB_GENRE_OPTIONS;
  filterMultipleGenreOptions: IMultiSelect[] = TMDB_MULTI_GENRE_OPTIONS;
  form: FormGroup;

  Data: Array<any> = [
    { name: 'Pear', value: 'pear' },
    { name: 'Plum', value: 'plum' },
    { name: 'Kiwi', value: 'kiwi' },
    { name: 'Apple', value: 'apple' },
    { name: 'Lime', value: 'lime' }
  ];

  constructor(private fb: FormBuilder) {
    this.filterFormGroup = new FormGroup({
      sortBy: new FormControl(TMDB_SORTING_OPTIONS[0]),
      genre: new FormControl(TMDB_GENRE_OPTIONS[0]),
      multiSelect: new FormControl(TMDB_MULTI_GENRE_OPTIONS)
    });

   }

  ngOnInit(): void {

    this.filterFormGroup.get('sortBy')
    .valueChanges
    .subscribe((option: ISelectOption) => {
      this.sortByChanged.emit(option.value.toString());
    });

    this.filterFormGroup.get('genre')
    .valueChanges
    .subscribe((option: ISelectOption) => {
      this.genreChanged.emit(option.value.toString());
    });

    // this.filterFormGroup.get('multi_genre')
    // .valueChanges
    // .subscribe((option: IMultiSelect) => {
    //   console.log(option);
    //   //this.multiGenreChanged.emit(option.value.toString());
    // });
  }

  onCheckboxChange(e) {
    console.log('test');
  }



}
