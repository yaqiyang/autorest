package fixtures.bodycomplex;

import com.fasterxml.jackson.databind.exc.InvalidFormatException;

import fixtures.bodycomplex.implementation.AutoRestComplexTestServiceImpl;
import fixtures.bodycomplex.models.Basic;
import fixtures.bodycomplex.models.CMYKColors;
import okhttp3.OkHttpClient;
import okhttp3.logging.HttpLoggingInterceptor;
import retrofit2.Retrofit;

import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;

public class BasicOperationsTests {
    private static AutoRestComplexTestService client;

    @BeforeClass
    public static void setup() {
        OkHttpClient.Builder clientBuilder = new OkHttpClient.Builder()
                .addInterceptor(new HttpLoggingInterceptor().setLevel(HttpLoggingInterceptor.Level.BODY));
        client = new AutoRestComplexTestServiceImpl("http://localhost:3000", clientBuilder, new Retrofit.Builder());
        client.withApiVersion("2015-05-01");
    }

    @Test
    public void getValid() throws Exception {
        Basic result = client.basics().getValid().getBody();
        Assert.assertEquals(2, result.id().intValue());
        Assert.assertEquals("abc", result.name());
        Assert.assertEquals(CMYKColors.YELLOW, result.color());
    }

    @Test
    public void putValid() throws Exception {
        Basic body = new Basic();
        body.withId(2);
        body.withName("abc");
        body.withColor(CMYKColors.MAGENTA);
        client.basics().putValid(body);
    }

    @Test
    public void getInvalid() throws Exception {
        try {
            client.basics().getInvalid();
            Assert.assertTrue(false);
        } catch (Exception exception) {
            // expected
            Assert.assertEquals(InvalidFormatException.class, exception.getClass());
        }
    }

    @Test
    public void getEmpty() throws Exception {
        Basic result = client.basics().getEmpty().getBody();
        Assert.assertNull(result.name());
    }

    @Test
    public void getNull() throws Exception {
        Basic result = client.basics().getNull().getBody();
        Assert.assertNull(result.name());
    }

    @Test
    public void getNotProvided() throws Exception {
        Assert.assertNull(client.basics().getNotProvided().getBody());
    }
}
