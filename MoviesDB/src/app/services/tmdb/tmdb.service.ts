import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IDiscoverResponse, ITvSeriesResponse, IPeopleResponse, IPeopleCombinedCreditsResponse } from 'src/app/interfaces/responses';
import { Observable } from 'rxjs';
import { IMovie } from 'src/app/interfaces/movie';
import { ITVShow } from 'src/app/interfaces/tv';
import { IPeopleDetail } from 'src/app/interfaces/peoples';
import { ISelectOption } from 'src/app/interfaces/select-option';
import { IMultiSelect } from 'src/app/interfaces/multi-select';


export const TMDB_SORTING_OPTIONS: ISelectOption[] = [
  {
    label: 'Popularity Descending',
    value: 'popularity.desc'
  },
  {
    label: 'Popularity Ascending',
    value: 'popularity.asc'
  }
];


export const TMDB_GENRE_OPTIONS: ISelectOption[] = [
  {
    label: 'All',
    value: ''
  },
  {
    label: 'Action',
    value: 28
  },
  {
    label: 'Adventure',
    value: 12
  },
  {
    label: 'Animation',
    value: 16
  }
];

export const TMDB_MULTI_GENRE_OPTIONS: IMultiSelect[] = [
  {
    label: 'All',
    value: '',
    selected: true
  },
  {
    label: 'Action',
    value: 28,
    selected: false
  },
  {
    label: 'Adventure',
    value: 12,
    selected: false
  },
  {
    label: 'Animation',
    value: 16,
    selected: false
  }
];

const generateYearsOptions = (): ISelectOption[] => {
  let yearsOptions: ISelectOption[] = [{label: 'All', value: ''}];

  for (let i: number = new Date().getFullYear(); i >= 1900; i--){
    yearsOptions.push({label: i.toString(), value: i});
  }
  return yearsOptions;
}

export const TMDB_YEARS_LIST: ISelectOption[] = generateYearsOptions();


@Injectable({
  providedIn: 'root'
})
export class TmdbService {
  private BASE_URL = 'https://api.themoviedb.org/3';
  private API_KEY = '773b03e328b585da4b114c52999b7dda';
  constructor(private httpClient: HttpClient) { }

  private buildUrl(endpoint: string, params?: object):string{
    const  queryParams = params? Object.keys(params).map(key => key + '=' + params[key]).join('&'): '';
    return `${this.BASE_URL}${endpoint}?api_key=${this.API_KEY}&${queryParams}`;
  }

  discover(params: any): Observable<IDiscoverResponse>{

    return this.httpClient
          .get<IDiscoverResponse>(this.buildUrl('/discover/movie', params));
  }

  movies(id: number): Observable<IMovie>{
    return this.httpClient
                .get<IMovie>(`${this.BASE_URL}/movie/${id}?api_key=${this.API_KEY}`);
  }

  tvSeries(params: any): Observable<ITvSeriesResponse>{
    return this.httpClient
          .get<ITvSeriesResponse>(this.buildUrl('/discover/tv', params));
  }

  tVshowDetails(id: number): Observable<ITVShow>{
    return this.httpClient
                .get<ITVShow>(`${this.BASE_URL}/tv/${id}?api_key=${this.API_KEY}`);
  }

  people(): Observable<IPeopleResponse>{
    return this.httpClient
          .get<IPeopleResponse>(`${this.BASE_URL}/person/popular?api_key=${this.API_KEY}`);
  }

  peopleDetails(id: number): Observable<IPeopleDetail>{
    return this.httpClient
                .get<IPeopleDetail>(`${this.BASE_URL}/person/${id}?api_key=${this.API_KEY}`);
  }

  peopleCombinedCredits(id: number): Observable<IPeopleCombinedCreditsResponse>{
    return this.httpClient.get<IPeopleCombinedCreditsResponse>(this.buildUrl(`/person/${id}/combined_credits`));


  }

}

