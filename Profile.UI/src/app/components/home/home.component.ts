import { Component } from '@angular/core';
import { Person } from '../../models/person';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  public person!: Person;

  constructor() {
    // reading from db can be done here
    this.person = new Person();
    this.person.name = "Silviu Teodor GROZA";
    this.person.title = "Software Developer | Angular - C# - .NET Framework";
    this.person.age = 32;
    this.person.email = "grz.silviu@gmail.com";
    this.person.phoneNumber = "+40728319031";
    this.person.address = "Saint-Julien-en-Genevois";
    this.person.about = "Currently living in Bruxelles, and some other stuff and i will complete this later. Still don t know what to write here.Currently living in Bruxelles, and some other stuff and i will complete this later. Still don t know what to write here.Currently living in Bruxelles, and some other stuff and i will complete this later. Still don t know what to write here.";
    this.person.skills = [];
    this.person.instagram = "https://www.instagram.com/gr.silviu/";
    this.person.linkedIn = "https://www.linkedin.com/in/silviu-teodor-groza-2b9b90128/";
  }
}
