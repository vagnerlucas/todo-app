import {Component, Output, EventEmitter, OnInit} from '@angular/core';

import {NgbModal, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'username-modal',
  templateUrl: './username.modal.template.html'
})

export class UserNameModalContent implements OnInit {

  title = 'User info';
  name: string;

  constructor(public activeModal: NgbActiveModal) {}
  
  ngOnInit(): void {
    this.name = '';
  }

}