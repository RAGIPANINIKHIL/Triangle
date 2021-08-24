import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'triangle-component',
  templateUrl: './traingle.component.html',
  styleUrls: ['./triangle.component.scss']
})
export class TraingleComponent implements OnInit {
  public triangleCordinates: TriangleCordinates;

  inputs: any = {
    point1: [],
    point2: [],
    point3: []
  };

  triangleText: string = "Enter The Coordinates in x,y Format";
  triangle: string = '';
  triangleinput: string = '';
  Text: string = "Enter The Triangle Number";
  error: boolean;
  errortext: string = "Entered Wrong Input Please Check The Format"

  constructor(
    @Inject('BASE_URL') private readonly baseUrl: string,
    private http: HttpClient) {
  }

  ngOnInit() {
    this.error = false;
  }
  queryChanged() {
    if (this.triangleinput.length === 2 || this.triangleinput.length === 3) {
      this.error = false;
      this.http.get<TriangleCordinates>(this.baseUrl + `api/triangle/GetTriangleCoordinates`, {
        params: {
          triangle: this.triangleinput
        }
      }).subscribe(result => {
        this.triangleCordinates = result;
        console.log('result');
      }, error => console.error(error));
    }
    else {
      this.error = true;
    }
  }

  getTraingle() {
    this.inputs.point1 = this.inputs.point1.split(',').map(e => Number.parseInt(e));
    this.inputs.point2 = this.inputs.point2.split(',').map(e => Number.parseInt(e));
    this.inputs.point3 = this.inputs.point3.split(',').map(e => Number.parseInt(e));
    if ((this.inputs.point1[0] >= 0 || this.inputs.point1[0] <= 60) &&
      (this.inputs.point1[1] >= 0 || this.inputs.point1[1] <= 60) &&
      (this.inputs.point2[0] >= 0 || this.inputs.point2[0] <= 60) &&
      (this.inputs.point2[1] >= 0 || this.inputs.point2[1] <= 60) &&
      (this.inputs.point3[0] >= 0 || this.inputs.point3[0] <= 60) &&
      (this.inputs.point3[1] >= 0 || this.inputs.point3[1] <= 60)) {

      this.error = false;
      this.http.post(this.baseUrl + `api/triangle/GetTriangleRowAndColumn`, this.inputs,{responseType: 'text'}).subscribe((result) => {
        this.triangle = result;
        console.log('result');
      }, error => console.error(error));
    }
    else {
      this.error = true
    }
    this.inputs.point1 = [];
    this.inputs.point2 = [];
    this.inputs.point3 = [];
  }

}

interface TriangleCordinates {
  point1: number[];
  point2: number[];
  point3: number[];
}


