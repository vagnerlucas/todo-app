import { Injectable, OnInit } from "@angular/core";
import { SignalR } from 'ng2-signalr';
import { Observable, Subject } from 'rxjs';
import { JokeModel } from '../models/joke.model';

@Injectable()
export class SocketService {

    private joke = new Subject<JokeModel>();

    constructor(private signalrClient: SignalR) { }

    getJoke = () => this.joke.asObservable();

    startConnection = () => {
        this.signalrClient.connect().then((c) => {
            let onJokeReceive$ = c.listenFor<JokeModel>('TellJoke');
            onJokeReceive$.subscribe(data => {
                if (data) {
                    this.joke.next(data);
                }
            });
        });
    }
}