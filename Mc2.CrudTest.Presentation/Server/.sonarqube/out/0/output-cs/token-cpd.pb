ï
^F:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Common\BaseEntity.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Common $
{ 
public 

abstract 
class 

BaseEntity $
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
DateTime 

CreateDate "
=># %
DateTime& .
.. /
Now/ 2
;2 3
public		 
DateTime		 
?		 
UpdatedDate		 $
=>		% '
DateTime		( 0
.		0 1
Now		1 4
;		4 5
public

 
DateTime

 
?

 
DeletedDate

 $
{

% &
get

' *
;

* +
set

, /
;

/ 0
}

1 2
public 
bool 
	IsDeleted 
=>  
false! &
;& '
} 
} ”
mF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Customer\Dtoes\CreateCustomerDto.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Customer &
.& '
Dtoes' ,
{ 
public 

class 
CreateCustomerDto "
{ 
public 
string 
? 
	FirstName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
? 
LastName 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
DateTime		 
DateOfBirth		 #
{		$ %
get		& )
;		) *
set		+ .
;		. /
}		0 1
public

 
ulong

 
PhoneNumber

  
{

! "
get

# &
;

& '
set

( +
;

+ ,
}

- .
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
BankAccountNumber (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} «
gF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Customer\Dtoes\CustomerDto.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Customer &
.& '
Dtoes' ,
{ 
public 

class 
CustomerDto 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
	FirstName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public		 
string		 
?		 
LastName		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
public

 
DateTime

 
DateOfBirth

 #
{

$ %
get

& )
;

) *
set

+ .
;

. /
}

0 1
public 
ulong 
? 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
BankAccountNumber (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} Ç
mF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Customer\Dtoes\UpdateCustomerDto.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Customer &
.& '
Dtoes' ,
{ 
public 

class 
UpdateCustomerDto "
{ 
public 
Guid 
? 
Id 
{ 
get 
; 
set "
;" #
}$ %
public 
string 
? 
	FirstName  
{! "
get# &
;& '
set( +
;+ ,
}- .
public		 
string		 
?		 
LastName		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
public

 
DateTime

 
DateOfBirth

 #
{

$ %
get

& )
;

) *
set

+ .
;

. /
}

0 1
public 
string 
? 
PhoneNumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
BankAccountNumber (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} ú
gF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Customer\Entities\Customes.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Customer &
.& '
Entities' /
{ 
public 

class 
Customer 
: 

BaseEntity &
{ 
public

 
string

 
	FirstName

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
DateOfBirth #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Column	 
( 
TypeName 
= 
$str #
)# $
]$ %
public 
ulong 
PhoneNumber  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
BankAccountNumber '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
} 
} Š
ŠF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Customer\Exceptions\CustomerDataNotValidateForCreateException.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Customer &
.& '

Exceptions' 1
{ 
public 

class 5
)CustomerDataNotValidateForCreateException :
:; <
	Exception= F
{ 
public 5
)CustomerDataNotValidateForCreateException 8
(8 9
)9 :
{ 	
}

 	
} 
} Š
ŠF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Customer\Exceptions\CustomerDataNotValidateForUpdateException.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Customer &
.& '

Exceptions' 1
{ 
public 

class 5
)CustomerDataNotValidateForUpdateException :
:; <
	Exception= F
{ 
public 5
)CustomerDataNotValidateForUpdateException 8
(8 9
)9 :
{ 	
}

 	
} 
} Ý
sF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Customer\Exceptions\CustomerNotCreated.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Customer &
.& '

Exceptions' 1
{ 
public 

class '
CustomerNotCreatedException ,
:- .
	Exception/ 8
{ 
} 
} ©
zF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Customer\Exceptions\CustomerNotFoundException.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Customer &
.& '

Exceptions' 1
{ 
public 

class %
CustomerNotFoundException *
:+ ,
	Exception- 6
{ 
public %
CustomerNotFoundException (
(( )
Guid) -

customerId. 8
)8 9
:: ;
base< @
(@ A
$"A C
$strC H
{H I

customerIdI S
}S T
"T U
)U V
{ 	
}

 	
} 
} â
wF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Core\Mc2.CrudTest.Domain\Customer\Exceptions\MobileNumberIsNotValid.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Domain 
. 
Customer &
.& '

Exceptions' 1
{ 
public 

class +
MobileNumberIsNotValidException 0
:1 2
	Exception3 <
{ 
public +
MobileNumberIsNotValidException .
(. /
)/ 0
{ 	
}

 	
} 
} 