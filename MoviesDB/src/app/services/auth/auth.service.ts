import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';
import { auth } from 'firebase/app';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import {AngularFirestore} from "@angular/fire/firestore";


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public userState: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  constructor(
    private angularFireAuth: AngularFireAuth,
    private router: Router,
    private angularFirestore: AngularFirestore
  ) {
    this.angularFireAuth.authState.subscribe(
      user => {
        this.userState.next(user);
      }
    )
  }

  loginWithOAuth(providerName: string){
    return this.angularFireAuth.signInWithPopup(
      this.getProvider(providerName)
    )
    .then(response => {
      this.updateUserInfo(response.user);
    })
    .catch(error => {
      console.log(error);
    })
  }

  getProvider(providerName: string){
    switch (providerName){
      case 'google':
      return new auth.GoogleAuthProvider();
      case 'facebook':
      return new auth.FacebookAuthProvider();
      case 'twitter':
      return new auth.TwitterAuthProvider();
    }
  }

  logOut(){
    this.angularFireAuth.signOut().then(
      () => {

        this.router.navigate(['/auth']);
      }
    ).catch(error => {

    })
  }

  loginWithEmailAndPassword(credentials: { email: string, password: string}, callback: (error?: any) => void){
    return this
      .angularFireAuth.signInWithEmailAndPassword(credentials.email, credentials.password)
            .then(response => {
              this.updateUserInfo(response.user);
              callback();
            })
            .catch(error => {
              callback(error);
            });
  }

  registerWithEmailAndPassword(credentials: { email: string, password: string}, callback: (error?: any) => void){
    return this
      .angularFireAuth
      .createUserWithEmailAndPassword(credentials.email, credentials.password)
            .then(response => {
              this.updateUserInfo(response.user);
              callback();
            })
            .catch(error => {
              callback(error);
            });
  }

  private getUserByUid(uid: string){
    return this.angularFirestore.doc(`/Users/${uid}`).valueChanges();
  }

  private updateUserInfo({uid, displayName, email, photoURL}: firebase.User){
    return this
      .angularFirestore
      .doc(`/Users/${uid}`)
      .set({
        uid,
        displayName,
        email,
        photoURL
      },{merge: true});
  }
}
