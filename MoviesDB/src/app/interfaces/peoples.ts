import { ITVShow } from './tv';
import { IMovie } from './movie';


export interface IPerson {
        popularity: number;
        known_for_department: string;
        gender: number;
        id: number;
        profile_path: string;
        adult: boolean;
        known_for: Array<ITVShow | IMovie>;
        name: string;
}

export interface IKnownFor {
        original_name: string;
        vote_count: number;
        poster_path: string;
        media_type: string;
        name: string;
        vote_average: number;
        id: number;
        first_air_date: string;
        original_language: string;
        genre_ids: number[];
        backdrop_path: string;
        overview: string;
        origin_country: string[];
        release_date: string;
        video?: boolean;
        title: string;
        original_title: string;
        adult?: boolean;
}

export interface IPeopleDetail {
        birthday: string;
        known_for_department: string;
        deathday?: any;
        id: number;
        name: string;
        also_known_as: string[];
        gender: number;
        biography: string;
        popularity: number;
        place_of_birth: string;
        profile_path: string;
        adult: boolean;
        imdb_id: string;
        homepage?: any;
}

export const isMovie = (media: ITVShow | IMovie): media is IMovie => {
  return (media as IMovie).title !== undefined;
}
