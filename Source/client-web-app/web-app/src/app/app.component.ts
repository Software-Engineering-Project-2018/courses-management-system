import { Component } from '@angular/core';
import { EventEmiterService } from './services/event.emmiter.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLoading = false;

  constructor(emitService: EventEmiterService) {
    emitService.changeEmitted$.subscribe(
      isLoading => {
        this.isLoading = isLoading;
      });
  }
}
