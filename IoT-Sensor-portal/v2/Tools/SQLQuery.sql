--delete from Histories where 1=1
--delete from LastValues where 1=1
--delete from Sensors where 1=1
--delete from SensorTypes where 1=1
--delete from AspNetUsers where UserName not like 'admin'
--delete from AspNetUsers where 1=1


select top (4) s.Id as 'Id', l.SensorIdICB as 'Id ICB',
	s.UserDefinedSensorName as 'Sensor`s name', s.IsPublic as 'Public',
	s.UserDefinedMinValue as 'Min', l.Value as 'Current', s.UserDefinedMaxValue as 'Max',
	l.[From], l.PollingInterval as 'Pol. Interval' from Sensors s
inner join LastValues l on s.Id = l.SensorId
order by s.AddedOn desc
select top (4) u.UserName as 'User name', u.Id as 'User Id' from AspNetUsers u
select * from SensorTypes
select top (4) * from ApplicationUserSensors
select * from Histories
select * from LastValues