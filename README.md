# Friendsbook <br />
 <br />
Classes to manage friendships between groups, <br />
People can have one-directional friendships and names, <br />
Groups can have people and their relationships. <br /> 
 <br />
## Create groups one frined at a time <br />
 <br />
```csharp 
var robbie = new Person("Robbie"); 
var heather = new Person("Heather"); 
Person.CreateFriendship(robbie, heather); 
heather.Unfriend(robbie) 
``` 
 <br />
Robbie <br />
Heather <br />
Corey <br />
Stranger <br />
 <br />
0 1 1 0 <br /> 
1 0 1 0 <br /> 
1 0 0 0 <br /> 
0 0 1 0 <br /> 
 <br />
My name is Robbie, <br />
My friends are <br />
	Heather <br />
	Corey <br />
 <br />
My name is Heather, <br />
My friends are <br />
	Robbie <br />
	Corey <br />
 <br />
My name is Corey, <br />
My friends are <br />
	Robbie <br />
 <br />
My name is Stranger, <br />
My friends are <br />
	Corey <br />
 <br />
# Create the group and the friendship topology all at once <br />
 <br />
```csharp 
var graph = new int[3,3] 
{ 
	{0,1,1}, 
	{1,0,0}, 
	{1,1,0} 
}; 
var names = new List<String> {"Gavin", "Scott", "Robbie"}; 
var group2 = new Group(graph, names); 
group2.Show(); 
foreach (Person p in group2.People) 
{ 
	p.Introduce(); 
}; 
``` 
 <br />
Gavin <br />
Scott <br />
Robbie <br />
 <br />
0 1 1 <br /> 
1 0 0 <br /> 
1 1 0 <br /> 
 <br />
My name is Gavin, <br />
My friends are <br />
	Scott <br />
	Robbie <br />
 <br />
My name is Scott, <br />
My friends are <br />
	Gavin <br />
 <br />
My name is Robbie, <br />
My friends are <br />
	Gavin <br />
	Scott <br />
