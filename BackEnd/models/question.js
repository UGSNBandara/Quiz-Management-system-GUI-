module.exports = (sequelize, DataTypes) => {

    const Question = sequelize.define("Question",{
    
    questionID:{
        type: DataTypes.INTEGER,
        autoIncrement: true,
        primaryKey: true,
    },
    text: {
        type: DataTypes.STRING,
        allowNull: false, 
    },
    quizID: {
        type: DataTypes.INTEGER, 
        allowNull: false,
    },
    });

    Question.associate = (models) => {
        Question.belongsTo(models.Quiz, {
            foreignKey: "quizID",
            onDelete: "CASCADE",
        });
    };
    return Question
}