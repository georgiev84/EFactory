import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {AngularFireAuth} from "@angular/fire/auth";
import {AuthService} from "../auth/auth.service";
import {AngularFirestore} from "@angular/fire/firestore";
import {IMovie} from "../../interfaces/movie";
import {ITVShow} from "../../interfaces/tv";
import {IFirestoreMedia} from "../../interfaces/firestore";
import {isMovie} from "../../interfaces/peoples";

@Injectable({
  providedIn: 'root'
})
export class DataStorageService {

  constructor(
    private httpClient: HttpClient,
    private angularFireAuth: AngularFireAuth,
    private authService: AuthService,
    private angularFirestore: AngularFirestore
  ) { }

  addMediaWatchlist(media: IMovie | ITVShow, userId: string, callback: (error?: string) => void){
    const mediaDetails: IFirestoreMedia = {
      id: media.id,
      createdAt: new Date(),
      originalTitle: isMovie(media)? media.title: media.original_name,
      posterPath: media.poster_path,
      isWatched: false,
      mediaType: isMovie(media)? 'movie' : 'tv-show'
    };
    this.angularFirestore
      .doc(`Lists/${userId}`)
      .collection<IFirestoreMedia[]>('watchlist')
      .doc<IFirestoreMedia>(`${media.id}`)
      .set(mediaDetails)
      .then(success => callback())
      .catch(error => callback(error));
  }

  addMediaFavouriteslist(media: IMovie | ITVShow, userId: string, callback: (error?: string) => void){
    const mediaDetails: IFirestoreMedia = {
      id: media.id,
      createdAt: new Date(),
      originalTitle: isMovie(media)? media.title: media.original_name,
      posterPath: media.poster_path,
      isWatched: false,
      mediaType: isMovie(media)? 'movie' : 'tv-show'
    };
    this.angularFirestore
      .doc(`Lists/${userId}`)
      .collection<IFirestoreMedia[]>('favourites')
      .doc<IFirestoreMedia>(`${media.id}`)
      .set(mediaDetails)
      .then(success => callback())
      .catch(error => callback(error));
  }
}
