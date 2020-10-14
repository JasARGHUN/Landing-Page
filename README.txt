1) To run the application you need to do a migration

2) Register new User here https://localhost:5001/mainpage/auth or https://localhost:5001/block/index

3) Add Admin Role to your User in Db. Go to bdo.AspNetUserClaims and add your UserId, 
next paste to ClaimType this string: http://schemas.microsoft.com/ws/2008/06/identity/claims/role
and add to ClaimValue: Admin.
Example:

Id  UserId		  ClaimType							  ClaimValue
1   bb3b3399-f5bb-4a67    http://schemas.microsoft.com/ws/2008/06/identity/claims/role	  Admin

 And the admin panel will be unlocked