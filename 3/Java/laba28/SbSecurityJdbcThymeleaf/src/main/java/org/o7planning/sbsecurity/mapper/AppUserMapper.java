package org.o7planning.sbsecurity.mapper;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.o7planning.sbsecurity.model.AppUser;
import org.springframework.jdbc.core.RowMapper;

public class AppUserMapper implements RowMapper<AppUser> {

    public static final String BASE_SQL //
            = "Select u.User_Id, u.User_Name, u.Encryted_Password From App_User u ";

    @Override
    public AppUser mapRow(ResultSet rs, int rowNum) throws SQLException {

        Long userId = rs.getLong("User_Id");
        String userName = rs.getString("User_Name");
        String encrytedPassword = rs.getString("Encryted_Password");

        return new AppUser(userId, userName, encrytedPassword);
    }

}
