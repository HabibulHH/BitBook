select *from  UserTable where id in  (select f_LIST.FriendId from  FriendList f_LIST join  FriendList user_list on f_LIST.UserId=user_list.UserId 
 and user_list.UserId=1)


