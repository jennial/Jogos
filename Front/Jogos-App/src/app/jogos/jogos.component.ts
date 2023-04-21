import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-jogos',
  templateUrl: './jogos.component.html',
  styleUrls: ['./jogos.component.scss']
})
export class JogosComponent implements OnInit{
  public jogos: any;

  constructor(private http: HttpClient){}

  ngOnInit(): void{
    this.getjogos();
  }

  public getjogos(): void{
    this.http.get('https://localhost:5001/api/jogos').subscribe(
     response => this.jogos = response,
     error => console.log(error)
    );


  }

}
