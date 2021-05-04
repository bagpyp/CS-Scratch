# Friendsbook

Classes to manage friendships between groups, 
People can have one-directional friendships and names,
Groups can have people and their relationships. 

## Create groups one frined at a time

```csharp
var robbie = new Person("Robbie");
var heather = new Person("Heather");
Person.CreateFriendship(robbie, heather);
heather.Unfriend(robbie)
```

Robbie
Heather
Corey
Stranger

0 1 1 0 
1 0 1 0 
1 0 0 0 
0 0 1 0 

My name is Robbie,
My friends are
	Heather
	Corey

My name is Heather,
My friends are
	Robbie
	Corey

My name is Corey,
My friends are
	Robbie

My name is Stranger,
My friends are
	Corey

# Create the group and the friendship topology all at once

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

Gavin
Scott
Robbie

0 1 1 
1 0 0 
1 1 0 

My name is Gavin,
My friends are
	Scott
	Robbie

My name is Scott,
My friends are
	Gavin

My name is Robbie,
My friends are
	Gavin
	Scott
