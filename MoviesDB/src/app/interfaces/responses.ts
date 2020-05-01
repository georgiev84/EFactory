import { IMovie } from './movie';
import { ITVShow } from './tv';
import { IPerson } from './peoples';

export interface IDiscoverResponse {
    page: number;
    total_results: number;
    total_pages: number;
    results: IMovie[];
}

export interface IMovieResponse {
}

export interface ITvSeriesResponse {
    page: number;
    total_results: number;
    total_pages: number;
    results: ITVShow[];
}

export interface IPeopleResponse {
    page: number;
    total_results: number;
    total_pages: number;
    results: IPerson[];
}

export interface IPeopleCombinedCreditsResponse{
  id: number;
  crew: Array<IPeopleCredit>;
  cast: Array<IPeopleCredit>;
}

export interface IPeopleCredit{
  id: number;
  department: string;
  original_language: string;
  original_title: string;
  job: string;
  overview: string;
  vote_count: 3;
  video: boolean;
  media_type: string;
  poster_path: string | null;
  backdrop_path: string | null;
  title: string;
  popularity: number;
  genre_ads: number[];
  vote_average: number;
  adult: false;
  release_date: string;
  credit_id: string;
}

