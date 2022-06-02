import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerAsAgency: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  switchRegister(): void {
    this.registerAsAgency = !this.registerAsAgency;
  }
}
