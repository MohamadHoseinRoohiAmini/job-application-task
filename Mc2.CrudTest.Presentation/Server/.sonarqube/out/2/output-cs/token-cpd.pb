Ã

^F:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\ApplicationServiceRegistration.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
{ 
public 

static 
class *
ApplicationServiceRegistration 6
{		 
public

 
static

 
IServiceCollection

 ((
ConfigureApplicationServices

) E
(

E F
this

F J
IServiceCollection

K ]
services

^ f
)

f g
{ 	
services 
. 
AddAutoMapper "
(" #
Assembly# +
.+ , 
GetExecutingAssembly, @
(@ A
)A B
)B C
;C D
services 
. 

AddMediatR 
(  
Assembly  (
.( ) 
GetExecutingAssembly) =
(= >
)> ?
)? @
;@ A
services 
. 
AddSingleton !
<! "
PhoneNumberUtil" 1
>1 2
(2 3
PhoneNumberUtil3 B
.B C
getInstanceC N
(N O
)O P
)P Q
;Q R
return 
services 
; 
} 	
} 
} ı
nF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Commands\Handlers\CreateCustomerCommandHandler.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
Commands# +
.+ ,
Handlers, 4
{ 
public 

class (
CreateCustomerCommandHandler -
:. /
IRequestHandler0 ?
<? @!
CreateCustomerCommand@ U
,U V
GuidW [
>[ \
{ 
private 
readonly 
ICustomerRepository ,
_customerRepository- @
;@ A
private 
readonly 
IMapper  
_mapper! (
;( )
public (
CreateCustomerCommandHandler +
(+ ,
ICustomerRepository, ?
customerRepository@ R
,R S
IMapperT [
mapper\ b
)b c
{ 	
_customerRepository 
=  !
customerRepository" 4
;4 5
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
Guid 
> 
Handle  &
(& '!
CreateCustomerCommand' <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 	
var 
	validator 
= 
new &
CreateCustomerDtoValidator  :
(: ;
); <
;< =
var 
validationResult  
=! "
await# (
	validator) 2
.2 3
ValidateAsync3 @
(@ A
requestA H
)H I
;I J
if 
( 
! 
validationResult !
.! "
IsValid" )
)) *
throw 
new 5
)CustomerDataNotValidateForCreateException C
(C D
)D E
;E F
var   
validationMobile    
=  ! "
ValidatePhone  # 0
.  0 1
MethodValidate  1 ?
(  ? @
request  @ G
.  G H
PhoneNumber  H S
??  T V
string  W ]
.  ] ^
Empty  ^ c
)  c d
;  d e
if!! 
(!! 
!!! 
validationMobile!! !
)!!! "
throw"" 
new"" +
MobileNumberIsNotValidException"" 9
(""9 :
)"": ;
;""; <
var$$ 
customer$$ 
=$$ 
_mapper$$ "
.$$" #
Map$$# &
<$$& '
Customer$$' /
>$$/ 0
($$0 1
request$$1 8
)$$8 9
;$$9 :
customer&& 
=&& 
await&& 
_customerRepository&& 0
.&&0 1
Add&&1 4
(&&4 5
customer&&5 =
)&&= >
;&&> ?
return(( 
customer(( 
.(( 
Id(( 
;(( 
})) 	
}** 
}++ È
nF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Commands\Handlers\DeleteCustomerCommandHandler.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
Commands# +
.+ ,
Handlers, 4
{		 
public

 

class

 (
DeleteCustomerCommandHandler

 -
:

. /
IRequestHandler

0 ?
<

? @!
DeleteCustomerCommand

@ U
>

U V
{ 
private 
readonly 
ICustomerRepository ,
_customerRepository- @
;@ A
public (
DeleteCustomerCommandHandler +
(+ ,
ICustomerRepository, ?
customerRepository@ R
)R S
{ 	
_customerRepository 
=  !
customerRepository" 4
;4 5
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '!
DeleteCustomerCommand' <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 	
var 
customer 
= 
await  
_customerRepository! 4
.4 5
Get5 8
(8 9
request9 @
.@ A
IdA C
)C D
;D E
if 
( 
customer 
is 
null  
)  !
throw 
new %
CustomerNotFoundException 3
(3 4
request4 ;
.; <
Id< >
)> ?
;? @
await 
_customerRepository %
.% &

HardDelete& 0
(0 1
customer1 9
)9 :
;: ;
return 
Unit 
. 
Value 
; 
} 	
} 
} º
nF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Commands\Handlers\UpdateCustomerCommandHandler.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
Commands# +
.+ ,
Handlers, 4
{ 
public 

class (
UpdateCustomerCommandHandler -
:. /
IRequestHandler0 ?
<? @!
UpdateCustomerCommand@ U
,U V
UnitW [
>[ \
{ 
private 
readonly 
ICustomerRepository ,
_customerRepository- @
;@ A
private 
readonly 
IMapper  
_mapper! (
;( )
public (
UpdateCustomerCommandHandler +
(+ ,
ICustomerRepository, ?
customerRepository@ R
,R S
IMapperT [
mapper\ b
)b c
{ 	
_customerRepository 
=  !
customerRepository" 4
;4 5
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '!
UpdateCustomerCommand' <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 	
var 
	validator 
= 
new &
UpdateCustomerDtoValidator  :
(: ;
); <
;< =
var 
validationResult  
=! "
await# (
	validator) 2
.2 3
ValidateAsync3 @
(@ A
requestA H
)H I
;I J
if 
( 
! 
validationResult !
.! "
IsValid" )
)) *
throw   
new   5
)CustomerDataNotValidateForUpdateException   C
(  C D
)  D E
;  E F
var"" 
validationMobile""  
=""! "
ValidatePhone""# 0
.""0 1
MethodValidate""1 ?
(""? @
request""@ G
.""G H
PhoneNumber""H S
??""T V
string""W ]
.""] ^
Empty""^ c
)""c d
;""d e
if## 
(## 
!## 
validationMobile## !
)##! "
throw$$ 
new$$ +
MobileNumberIsNotValidException$$ 9
($$9 :
)$$: ;
;$$; <
var&& 
customer&& 
=&& 
await&&  
_customerRepository&&! 4
.&&4 5
Get&&5 8
(&&8 9
request&&9 @
.&&@ A
Id&&A C
??&&D F
Guid&&G K
.&&K L
NewGuid&&L S
(&&S T
)&&T U
)&&U V
;&&V W
_mapper(( 
.(( 
Map(( 
((( 
request(( 
,((  
customer((! )
)(() *
;((* +
if** 
(** 
customer** 
==** 
null**  
)**  !
throw++ 
new++ '
CustomerNotCreatedException++ 5
(++5 6
)++6 7
;++7 8
await-- 
_customerRepository-- %
.--% &
Update--& ,
(--, -
customer--- 5
)--5 6
;--6 7
return// 
Unit// 
.// 
Value// 
;// 
}00 	
}11 
}22 Ü
gF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Commands\Requests\CreateCustomerCommand.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
Commands# +
.+ ,
Requests, 4
{ 
public 

class !
CreateCustomerCommand &
:' (
IRequest) 1
<1 2
Guid2 6
>6 7
{ 
public		 
string		 
?		 
	FirstName		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
public

 
string

 
?

 
LastName

 
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
public 
DateTime 
DateOfBirth #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Column	 
( 
TypeName 
= 
$str (
)( )
]) *
public 
string 
? 
PhoneNumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
BankAccountNumber (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} ·
gF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Commands\Requests\DeleteCustomerCommand.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
Commands# +
.+ ,
Requests, 4
{ 
public 

class !
DeleteCustomerCommand &
:' (
IRequest) 1
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
}		 
}

 ¢
gF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Commands\Requests\UpdateCustomerCommand.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
Commands# +
.+ ,
Requests, 4
{ 
public 

class !
UpdateCustomerCommand &
:' (
IRequest) 1
<1 2
Unit2 6
>6 7
{ 
public 
Guid 
? 
Id 
{ 
get 
; 
set "
;" #
}$ %
public		 
string		 
?		 
	FirstName		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
public

 
string

 
?

 
LastName

 
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
public 
DateTime 
DateOfBirth #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
string 
? 
PhoneNumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
BankAccountNumber (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} ∑
hF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Contracts\Extensions\ValidatePhoneNumber.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
	Contracts# ,
., -

Extensions- 7
{ 
public 

static 
class 
ValidatePhone %
{ 
public 
static 
bool 
MethodValidate )
() *
string* 0

phoneNumer1 ;
); <
{ 	
var		 
_phoneNumberUtil		  
=		! "
com		# &
.		& '
google		' -
.		- .
i18n		. 2
.		2 3
phonenumbers		3 ?
.		? @
PhoneNumberUtil		@ O
.		O P
getInstance		P [
(		[ \
)		\ ]
;		] ^
try

 
{ 
var 
number 
= 
_phoneNumberUtil -
.- .
parse. 3
(3 4

phoneNumer4 >
,> ?
string@ F
.F G
EmptyG L
)L M
;M N
var 
getType 
= 
_phoneNumberUtil .
.. /
getNumberType/ <
(< =
number= C
)C D
;D E
if 
( 
! 
_phoneNumberUtil %
.% &
isValidNumber& 3
(3 4
number4 :
): ;
||< >
getType? F
!=G I
PhoneNumberTypeJ Y
.Y Z
MOBILEZ `
)` a
{ 
return 
false  
;  !
} 
else 
{ 
return 
true 
;  
} 
} 
catch 
( 
com 
. 
google 
. 
i18n "
." #
phonenumbers# /
./ 0 
NumberParseException0 D
)D E
{ 
return 
false 
; 
} 
} 	
} 
} ï
jF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Contracts\Repositories\ICustomerRepository.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
	Contracts# ,
., -
Repositories- 9
{ 
public 

	interface 
ICustomerRepository (
:) *
IGenericRepository+ =
<= >
Customer> F
>F G
{ 
} 
} ≈

iF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Contracts\Repositories\IGenericRepository.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
	Contracts# ,
., -
Repositories- 9
{ 
public 

	interface 
IGenericRepository '
<' (
T( )
>) *
where+ 0
T1 2
:3 4
class5 :
{ 
Task		 
<		 
T		 
?		 
>		 
Get		 
(		 
Guid		 
id		 
)		 
;		 
Task

 
<

 
IReadOnlyList

 
<

 
T

 
>

 
>

 
GetAll

 %
(

% &
)

& '
;

' (
Task 
< 
T 
> 
Add 
( 
T 
entity 
) 
; 
Task 
< 
T 
> 
Update 
( 
T 
entity 
)  
;  !
Task 

HardDelete 
( 
T 
entity  
)  !
;! "
} 
} ©
oF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Contracts\Validators\CreateCustomerDtoValidator.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
	Contracts# ,
., -

Validators- 7
{ 
public 

class &
CreateCustomerDtoValidator +
:, -
AbstractValidator. ?
<? @!
CreateCustomerCommand@ U
>U V
{ 
public &
CreateCustomerDtoValidator )
() *
)* +
{		 	
RuleFor

 
(

 
x

 
=>

 
x

 
.

 
Email

  
)

  !
.

! "
NotEmpty

" *
(

* +
)

+ ,
.

, -
WithMessage

- 8
(

8 9
$str

9 L
)

L M
.

M N
EmailAddress

N Z
(

Z [
)

[ \
.

\ ]
WithMessage

] h
(

h i
$str

i |
)

| }
;

} ~
RuleFor 
( 
x 
=> 
x 
. 
BankAccountNumber ,
), -
.- .
NotEmpty. 6
(6 7
)7 8
.8 9
Matches9 @
(@ A
$strA J
)J K
.K L
WithMessageL W
(W X
$strX x
)x y
;y z
RuleFor 
( 
x 
=> 
x 
. 
	FirstName $
)$ %
.% &
NotEmpty& .
(. /
)/ 0
;0 1
RuleFor 
( 
x 
=> 
x 
. 
LastName #
)# $
.$ %
NotEmpty% -
(- .
). /
;/ 0
} 	
} 
} ƒ
iF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Contracts\Validators\PhoneNumberException.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
	Contracts# ,
., -

Validators- 7
{ 
public 

class  
PhoneNumberException %
:& '
	Exception( 1
{ 
public  
PhoneNumberException #
(# $
)$ %
{ 	
}

 	
} 
} ‹
qF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Contracts\Validators\PhoneNumberNotValidException.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
	Contracts# ,
., -

Validators- 7
{ 
public 

class (
PhoneNumberNotValidException -
:. /
	Exception0 9
{ 
public (
PhoneNumberNotValidException +
(+ ,
), -
{ 	
}

 	
} 
} ˚
oF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Contracts\Validators\UpdateCustomerDtoValidator.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
	Contracts# ,
., -

Validators- 7
{ 
public 

class &
UpdateCustomerDtoValidator +
:, -
AbstractValidator. ?
<? @!
UpdateCustomerCommand@ U
>U V
{ 
public &
UpdateCustomerDtoValidator )
() *
)* +
{		 	
RuleFor

 
(

 
x

 
=>

 
x

 
.

 
Id

 
)

 
.

 
NotEmpty

 '
(

' (
)

( )
;

) *
RuleFor 
( 
x 
=> 
x 
. 
Email  
)  !
.! "
NotEmpty" *
(* +
)+ ,
., -
WithMessage- 8
(8 9
$str9 L
)L M
.M N
EmailAddressN Z
(Z [
)[ \
.\ ]
WithMessage] h
(h i
$stri |
)| }
;} ~
RuleFor 
( 
x 
=> 
x 
. 
BankAccountNumber ,
), -
.- .
NotEmpty. 6
(6 7
)7 8
.8 9
Matches9 @
(@ A
$strA J
)J K
.K L
WithMessageL W
(W X
$strX x
)x y
;y z
RuleFor 
( 
x 
=> 
x 
. 
	FirstName $
)$ %
.% &
NotEmpty& .
(. /
)/ 0
;0 1
RuleFor 
( 
x 
=> 
x 
. 
LastName #
)# $
.$ %
NotEmpty% -
(- .
). /
;/ 0
} 	
} 
} ·
WF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Profiles\MappingProfile.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
Profiles# +
{		 
public

 

class

 
MappingProfile

 
:

  !
Profile

" )
{ 
public 
MappingProfile 
( 
) 
{ 	
	CreateMap 
< 
Customer 
, 
CustomerDto *
>* +
(+ ,
), -
.- .

ReverseMap. 8
(8 9
)9 :
;: ;
} 	
} 
} ∏
jF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Queries\Handlers\GetCustomerRequestHandler.cs
	namespace

 	
Mc2


 
.

 
CrudTest

 
.

 
Application

 "
.

" #
Queries

# *
.

* +
Handlers

+ 3
{ 
public 

class %
GetCustomerRequestHandler *
:+ ,
IRequestHandler- <
<< =
GetCustomerRequest= O
,O P
CustomerDtoQ \
>\ ]
{ 
private 
readonly 
ICustomerRepository ,
_customerRepository- @
;@ A
private 
readonly 
IMapper  
_mapper! (
;( )
public %
GetCustomerRequestHandler (
(( )
ICustomerRepository) <
customerRepository= O
,O P
IMapperQ X
mapperY _
)_ `
{ 	
_customerRepository 
=  !
customerRepository" 4
;4 5
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
CustomerDto %
>% &
Handle' -
(- .
GetCustomerRequest. @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 	
var 
customer 
= 
await  
_customerRepository! 4
.4 5
Get5 8
(8 9
request9 @
.@ A
IdA C
)C D
;D E
if 
( 
customer 
is 
null  
)  !
throw" '
new( +%
CustomerNotFoundException, E
(E F
requestF M
.M N
IdN P
)P Q
;Q R
return 
_mapper 
. 
Map 
< 
CustomerDto *
>* +
(+ ,
customer, 4
)4 5
;5 6
} 	
} 
} ê
cF:\Projects\RayanKar - JobTest - C#\Mc2.CrudTest.Application\Queries\Requests\GetCustomerRequest.cs
	namespace 	
Mc2
 
. 
CrudTest 
. 
Application "
." #
Queries# *
.* +
Requests+ 3
{ 
public 

class 
GetCustomerRequest #
:$ %
IRequest& .
<. /
CustomerDto/ :
>: ;
{ 
public		 
Guid		 
Id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
}

 
} 