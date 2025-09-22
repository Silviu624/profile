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
    this.person.phone = "+40728319031";
    this.person.address = "Saint-Julien-en-Genevois";
    this.person.about = "Currently living in France, in Saint-Julien-en-Genevois. Graduated with a degree in Computer Science from the University of Petroleum and Gas from Ploiesti, specializing in software development. Most recently, served as a Tech Lead at Cognyte, where responsibilities included overseeing a team of eight developers, managing over ten active projects, and delivering technical decisions to ensure successful outcomes. Proficient in Angular, C#, and .NET Framework, with additional expertise in Docker, Kubernetes, and ASP.NET Web API. Motivated by problem-solving and enabling team collaboration, contributed to both customer-focused solutions and internal technical advancements. Prior experience includes ERP application development and AutoCAD integrations.";
    this.person.skills = [];
  }
}
