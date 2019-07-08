import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    testRooms: TestRoom[];

    newTestRoom: TestRoom;

  constructor() { }

    ngOnInit() {
        this.testRooms = [];

    }

    addRoom(testRoom: TestRoom) {
        this.testRooms.push(testRoom);
    }

}

export class TestRoom {

    adults: number;
    children: number;
}