import {Component, Output, EventEmitter} from '@angular/core';

import {NgbModal, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'username-modal',
  templateUrl: './username.modal.template.html'
})
export class UserNameModalContent {
  title = 'User info';
  
  @Output() $eventEmitter = new EventEmitter();

  constructor(private activeModal: NgbActiveModal) {}
}