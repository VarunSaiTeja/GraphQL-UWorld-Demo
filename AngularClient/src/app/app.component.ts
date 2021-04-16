import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { gql, Apollo } from 'apollo-angular';
import { HomePage, User } from './models';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'AngGraph';
  homePageData: HomePage;
  userSource: MatTableDataSource<User> = new MatTableDataSource<User>();
  displayedColumns: string[] = ['firstName', 'lastName', 'role', 'isActive'];
  constructor(private apollo: Apollo) {

  }

  ngOnInit() {
    this.getPageLoadData();
    this.subscribeUserAddedToGroup();
  }

  getPageLoadData() {
    this.apollo
      .watchQuery({
        query: gql`
          query($impId:Int){
            groups(where:{implementationId:{eq:$impId}}){
            groupName,
              leadFaculty{
                firstName,
                lastName
              },
              users{
                user{
                  firstName,
                  lastName,
                  role,
                  isActive
                }
              }
            }
          }
        `,
        variables: { impId: 1 }
      })
      .valueChanges.subscribe((result: any) => {
        this.homePageData = result?.data;
        console.log(this.homePageData);
        this.userSource.data = this.homePageData.groups[0].users.map(u => u.user);
        // this.loading = result.loading;
        // this.error = result.error;
      });
  }

  subscribeUserAddedToGroup() {
    this.apollo
      .subscribe<User>({
        query: gql`
          subscription{
            onUserAddedToGroup(groupId:1){
              user{
                userId,
                firstName,
                lastName,
                role,
                isActive
              }
            }
          }
        `,
        fetchPolicy: "no-cache"
      })
      .subscribe(result => {
        this.userSource.data.push(result.data);
      });
  }
}
