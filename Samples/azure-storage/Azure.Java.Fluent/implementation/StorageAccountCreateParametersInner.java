/**
 */

package petstore.implementation;

import java.util.Map;
import petstore.StorageAccountPropertiesCreateParameters;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * The parameters to provide for the account.
 */
public class StorageAccountCreateParametersInner {
    /**
     * Resource location.
     */
    @JsonProperty(required = true)
    private String location;

    /**
     * Resource tags.
     */
    private Map<String, String> tags;

    /**
     * The properties property.
     */
    private StorageAccountPropertiesCreateParameters properties;

    /**
     * Get the location value.
     *
     * @return the location value
     */
    public String location() {
        return this.location;
    }

    /**
     * Set the location value.
     *
     * @param location the location value to set
     * @return the StorageAccountCreateParametersInner object itself.
     */
    public StorageAccountCreateParametersInner withLocation(String location) {
        this.location = location;
        return this;
    }

    /**
     * Get the tags value.
     *
     * @return the tags value
     */
    public Map<String, String> tags() {
        return this.tags;
    }

    /**
     * Set the tags value.
     *
     * @param tags the tags value to set
     * @return the StorageAccountCreateParametersInner object itself.
     */
    public StorageAccountCreateParametersInner withTags(Map<String, String> tags) {
        this.tags = tags;
        return this;
    }

    /**
     * Get the properties value.
     *
     * @return the properties value
     */
    public StorageAccountPropertiesCreateParameters properties() {
        return this.properties;
    }

    /**
     * Set the properties value.
     *
     * @param properties the properties value to set
     * @return the StorageAccountCreateParametersInner object itself.
     */
    public StorageAccountCreateParametersInner withProperties(StorageAccountPropertiesCreateParameters properties) {
        this.properties = properties;
        return this;
    }

}
