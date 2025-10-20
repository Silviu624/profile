import { Component, OnInit } from '@angular/core';
import { Person } from '../../models/person';

import { AuthService } from '../../services/auth.service';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  public person!: Person;
  public editMode: boolean = false;

  constructor(private _authService: AuthService, private _personService: PersonService) { }

  ngOnInit(): void {
    this.person = this._personService.getPerson().subscribe({
      next: (data) => this.person = data,
      error: (err) => console.error('Error fetching person data', err)
    }) as unknown as Person;
  }

  public isLoggedInFunction(): boolean {
    return this._authService.isLoggedIn();
  }

  public save(): void {
    this.editMode = !this.editMode
    if (!this.editMode) {
      this._personService.updatePerson(this.person).subscribe({
        next: () => console.log('Person data updated successfully'),
        error: (err) => console.error('Error updating person data', err)
      });
    }
  }
}
