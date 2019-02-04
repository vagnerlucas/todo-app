import { Component, OnInit } from '@angular/core';
import { SocketService } from 'src/app/services/socket.service';
import { Observable } from 'rxjs';
import { JokeModel } from 'src/app/models/joke.model';

@Component({
  selector: 'app-joke',
  templateUrl: './joke.component.html',
  styleUrls: ['./joke.component.css']
})
export class JokeComponent implements OnInit {

  joke:JokeModel;

  constructor(private socketService: SocketService) { 
  }

  ngOnInit() {
    this.socketService.startConnection();
    this.socketService.getJoke().subscribe(joke => this.joke = joke);
  }

}
